using OpenCvSharp.Internal;

namespace OpenCvSharp.Plot;

/// <summary>
/// Class to plot 2D data.
/// </summary>
public class Plot2d : Algorithm
{
    private Plot2d(IntPtr smartPtr, IntPtr rawPtr)
        : base(smartPtr, rawPtr, static p => NativeMethods.HandleException(NativeMethods.plot_Ptr_Plot2d_delete(p)))
    {
    }

    /// <summary>
    /// Creates a Plot2d object.
    /// </summary>
    /// <param name="data">1xN or Nx1 matrix containing Y values of points to plot. X values
    /// will be equal to indexes of corresponding elements in data matrix.</param>
    public static Plot2d Create(InputArray data)
    {
        NativeMethods.HandleException(
            NativeMethods.plot_Plot2d_create1(data.Proxy, out var smartPtr));
        GC.KeepAlive(data.Source);

        NativeMethods.HandleException(NativeMethods.plot_Ptr_Plot2d_get(smartPtr, out var rawPtr));
        return new Plot2d(smartPtr, rawPtr);
    }

    /// <summary>
    /// Creates a Plot2d object.
    /// </summary>
    /// <param name="dataX">1xN or Nx1 matrix X values of points to plot.</param>
    /// <param name="dataY">1xN or Nx1 matrix containing Y values of points to plot.</param>
    public static Plot2d Create(InputArray dataX, InputArray dataY)
    {
        NativeMethods.HandleException(
            NativeMethods.plot_Plot2d_create2(dataX.Proxy, dataY.Proxy, out var smartPtr));
        GC.KeepAlive(dataX.Source);
        GC.KeepAlive(dataY.Source);

        NativeMethods.HandleException(NativeMethods.plot_Ptr_Plot2d_get(smartPtr, out var rawPtr));
        return new Plot2d(smartPtr, rawPtr);
    }

    /// <summary>
    /// Sets the minimum X value of the plot.
    /// </summary>
    public virtual void SetMinX(double plotMinX)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.plot_Plot2d_setMinX(Handle, plotMinX));
    }

    /// <summary>
    /// Sets the minimum Y value of the plot.
    /// </summary>
    public virtual void SetMinY(double plotMinY)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.plot_Plot2d_setMinY(Handle, plotMinY));
    }

    /// <summary>
    /// Sets the maximum X value of the plot.
    /// </summary>
    public virtual void SetMaxX(double plotMaxX)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.plot_Plot2d_setMaxX(Handle, plotMaxX));
    }

    /// <summary>
    /// Sets the maximum Y value of the plot.
    /// </summary>
    public virtual void SetMaxY(double plotMaxY)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.plot_Plot2d_setMaxY(Handle, plotMaxY));
    }

    /// <summary>
    /// Sets the width of the plotted lines.
    /// </summary>
    public virtual void SetPlotLineWidth(int plotLineWidth)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.plot_Plot2d_setPlotLineWidth(Handle, plotLineWidth));
    }

    /// <summary>
    /// Switches data visualization mode.
    /// </summary>
    /// <param name="needPlotLine">if true then neighbour plot points will be connected by lines.
    /// In other case data will be plotted as a set of standalone points.</param>
    public virtual void SetNeedPlotLine(bool needPlotLine)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.plot_Plot2d_setNeedPlotLine(Handle, needPlotLine));
    }

    /// <summary>
    /// Sets the color of the plotted lines.
    /// </summary>
    public virtual void SetPlotLineColor(Scalar plotLineColor)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.plot_Plot2d_setPlotLineColor(Handle, plotLineColor));
    }

    /// <summary>
    /// Sets the background color of the plot.
    /// </summary>
    public virtual void SetPlotBackgroundColor(Scalar plotBackgroundColor)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.plot_Plot2d_setPlotBackgroundColor(Handle, plotBackgroundColor));
    }

    /// <summary>
    /// Sets the axis color of the plot.
    /// </summary>
    public virtual void SetPlotAxisColor(Scalar plotAxisColor)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.plot_Plot2d_setPlotAxisColor(Handle, plotAxisColor));
    }

    /// <summary>
    /// Sets the grid color of the plot.
    /// </summary>
    public virtual void SetPlotGridColor(Scalar plotGridColor)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.plot_Plot2d_setPlotGridColor(Handle, plotGridColor));
    }

    /// <summary>
    /// Sets the text color of the plot.
    /// </summary>
    public virtual void SetPlotTextColor(Scalar plotTextColor)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.plot_Plot2d_setPlotTextColor(Handle, plotTextColor));
    }

    /// <summary>
    /// Sets the size of the plot image.
    /// </summary>
    public virtual void SetPlotSize(int plotSizeWidth, int plotSizeHeight)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.plot_Plot2d_setPlotSize(Handle, plotSizeWidth, plotSizeHeight));
    }

    /// <summary>
    /// Sets whether to show the grid.
    /// </summary>
    public virtual void SetShowGrid(bool needShowGrid)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.plot_Plot2d_setShowGrid(Handle, needShowGrid));
    }

    /// <summary>
    /// Sets whether to show the text.
    /// </summary>
    public virtual void SetShowText(bool needShowText)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.plot_Plot2d_setShowText(Handle, needShowText));
    }

    /// <summary>
    /// Sets the number of grid lines.
    /// </summary>
    public virtual void SetGridLinesNumber(int gridLinesNumber)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.plot_Plot2d_setGridLinesNumber(Handle, gridLinesNumber));
    }

    /// <summary>
    /// Sets whether to invert the orientation of the plot.
    /// </summary>
    public virtual void SetInvertOrientation(bool invertOrientation)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.plot_Plot2d_setInvertOrientation(Handle, invertOrientation));
    }

    /// <summary>
    /// Sets the index of a point which coordinates will be printed on the top left corner of the plot
    /// (if ShowText flag is true).
    /// </summary>
    /// <param name="pointIdx">index of the required point in data array.</param>
    public virtual void SetPointIdxToPrint(int pointIdx)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.plot_Plot2d_setPointIdxToPrint(Handle, pointIdx));
    }

    /// <summary>
    /// Renders the plot to an image.
    /// </summary>
    public virtual void Render(OutputArray plotResult)
    {
        ThrowIfDisposed();
        NativeMethods.HandleException(NativeMethods.plot_Plot2d_render(Handle, plotResult.Proxy));
        GC.KeepAlive(plotResult.Source);
    }
}
