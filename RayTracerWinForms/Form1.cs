using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Windows.Forms;
using RayTracerWinForms.Core;

namespace RayTracerWinForms
{
    public partial class Form1 : Form
    {
        private Bitmap? _currentBitmap;

        public Form1()
        {
            InitializeComponent();
            lblStatus.Text = "Pronto. Clique em Renderizar.";
            Text = "Ray Tracer — Windows Forms";
        }

        // ------------------------------------------------------------
        // Renderizar
        // ------------------------------------------------------------
        private async void btnRender_Click(object sender, EventArgs e)
        {
            // Desabilita botões durante renderização
            SetUiEnabled(false);
            lblStatus.Text = "Renderizando...";
            Cursor = Cursors.WaitCursor;

            try
            {
                // 1. Resolução (clamp 5..1280 × 5..720)
                int width = Math.Clamp((int)numWidth.Value, 5, 1280);
                int height = Math.Clamp((int)numHeight.Value, 5, 720);

                // 2. Câmera
                Vec3 eye = new(
                    (double)numCamX.Value,
                    (double)numCamY.Value,
                    (double)numCamZ.Value);
                Vec3 look = new(0, 0.5, 0);
                Vec3 up = new(0, 1, 0);
                double fov = trackFov.Value;

                // 3. Cena
                Scene scene = BuildScene();

                // 4. Renderização em background (não congela a UI)
                int spp = (int)numSpp.Value;
                var camera = new Camera(eye, look, up, fov, width, height);
                var renderer = new Renderer { Scene = scene, Camera = camera };

                Vec3[,] buffer = await Task.Run(() => renderer.Render(spp));

                // 5. Converter para Bitmap
                Bitmap newBitmap = BitmapConverter.ToBitmap(buffer);

                // 6. Trocar imagem com segurança
                Image? oldImage = pictureBoxRender.Image;
                pictureBoxRender.Image = newBitmap;
                oldImage?.Dispose();

                _currentBitmap?.Dispose();
                _currentBitmap = newBitmap;

                lblStatus.Text = $"Pronto. {width}×{height} — FOV {fov}° — {spp} spp";
                Text = $"Ray Tracer — {width}×{height} — FOV {fov}°";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Erro na renderização.";
                MessageBox.Show(
                    $"Erro ao renderizar:\n\n{ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                SetUiEnabled(true);
            }
        }

        // ------------------------------------------------------------
        // Salvar PNG
        // ------------------------------------------------------------
        private void btnSavePng_Click(object sender, EventArgs e)
        {
            if (_currentBitmap == null)
            {
                MessageBox.Show(
                    "Renderize uma imagem antes de salvar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            using var sfd = new SaveFileDialog
            {
                Filter = "PNG Image|*.png",
                DefaultExt = "png",
                AddExtension = true,
                FileName = $"raytrace_{DateTime.Now:yyyyMMdd_HHmmss}.png"
            };

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                _currentBitmap.Save(sfd.FileName, ImageFormat.Png);
                lblStatus.Text = $"PNG salvo: {System.IO.Path.GetFileName(sfd.FileName)}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao salvar PNG:\n\n{ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ------------------------------------------------------------
        // FOV — atualiza o label
        // ------------------------------------------------------------
        private void trackFov_ValueChanged(object sender, EventArgs e)
        {
            lblFov.Text = $"FOV: {trackFov.Value}°";
        }

        // ------------------------------------------------------------
        // Habilita/desabilita controles durante renderização
        // ------------------------------------------------------------
        private void SetUiEnabled(bool enabled)
        {
            btnRender.Enabled = enabled;
            btnSavePng.Enabled = enabled;
            numWidth.Enabled = enabled;
            numHeight.Enabled = enabled;
            trackFov.Enabled = enabled;
            numCamX.Enabled = enabled;
            numCamY.Enabled = enabled;
            numCamZ.Enabled = enabled;
            numSpp.Enabled = enabled;
        }

        // ------------------------------------------------------------
        // Monta a cena de exemplo
        // ------------------------------------------------------------
        private static Scene BuildScene()
        {
            var scene = new Scene
            {
                Ambient = new Vec3(0.05, 0.05, 0.05)
            };

            // ---------- Materiais ----------
            var matRed = new Material
            {
                Color = new Vec3(0.85, 0.10, 0.10),
                Ka = 0.1,
                Kd = 0.7,
                Ks = 0.6,
                Shininess = 80,
                Reflectivity = 0.2
            };

            var matBlue = new Material
            {
                Color = new Vec3(0.10, 0.20, 0.90),
                Ka = 0.1,
                Kd = 0.7,
                Ks = 0.5,
                Shininess = 120,
                Reflectivity = 0.0
            };

            var matFloor = new Material
            {
                Color = new Vec3(0.60, 0.60, 0.60),
                Ka = 0.1,
                Kd = 0.7,
                Ks = 0.1,
                Shininess = 10,
                Reflectivity = 0.0
            };

            var matGreen = new Material
            {
                Color = new Vec3(0.10, 0.80, 0.30),
                Ka = 0.1,
                Kd = 0.7,
                Ks = 0.4,
                Shininess = 40,
                Reflectivity = 0.0
            };

            // ---------- Esferas ----------
            scene.Shapes.Add(new Sphere(new Vec3(-1.5, 0.8, 0.0), 0.8, matRed));
            scene.Shapes.Add(new Sphere(new Vec3(1.5, 0.6, -1.0), 0.6, matBlue));

            // ---------- Chão: dois triângulos ----------
            const double s = 10.0;
            Vec3 p00 = new(-s, 0, -s);
            Vec3 p10 = new(s, 0, -s);
            Vec3 p11 = new(s, 0, s);
            Vec3 p01 = new(-s, 0, s);

            scene.Shapes.Add(new Triangle(p00, p10, p11, matFloor));
            scene.Shapes.Add(new Triangle(p00, p11, p01, matFloor));

            // ---------- Triângulo vertical (Möller–Trumbore) ----------
            scene.Shapes.Add(new Triangle(
                new Vec3(0.0, 0.0, -2.5),
                new Vec3(1.5, 0.0, -3.5),
                new Vec3(-1.5, 0.0, -3.5),
                matGreen));

            // ---------- Luzes ----------
            scene.Lights.Add(new Light(
                new Vec3(-4, 6, 4),
                new Vec3(0.90, 0.90, 0.90)));

            scene.Lights.Add(new Light(
                new Vec3(5, 4, 2),
                new Vec3(0.40, 0.40, 0.50)));

            return scene;
        }
    }
}